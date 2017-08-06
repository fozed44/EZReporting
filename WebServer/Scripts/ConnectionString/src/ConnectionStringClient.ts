/// <reference path="c:/Projects/EZReporting/Webserver/Scripts/typings/jQuery/jQuery.d.ts" />

import 'jQuery';
import * as cs from './ConnectionStringModels';
import * as u from './Utilities';

export class connectionStringClient {
    private _connectionStrings: Array<cs.connectionString>;

    private _endpoints: cs.connectionStringEndpoints;

    public setEndpoints(endpoints: cs.connectionStringEndpoints) {
        this._endpoints = endpoints;
    }

    public get Endpoints() {
        var result: cs.connectionStringEndpoints;
        result = new cs.connectionStringEndpoints();
        result.load = this._endpoints.load;
        result.create = this._endpoints.create;
        result.update = this._endpoints.update;
        result.delete = this._endpoints.delete;
        return result;
    }

    public load(then: () => void = () => { }): void {
        var _self = this;
        $.ajax({
            url: this._endpoints.load,
            method: 'GET',
            success: function (data: cs.connectionStringsServerResult) {
                if (!data || !data.success)
                    throw new Error("Failed to receive connection string data.");
                _self._connectionStrings = data.connectionStrings;
                if (typeof then === 'function')
                    then();
            },
            error: function () {
                throw new Error("Failed to receive connection string data.");
            }
        });
    }

    public getConnectionStrings(): cs.connectionString[] {
        return this._connectionStrings;
    }

    public add(conString: cs.connectionString, then: () => void = () => { }): void {
        var _self = this;
        $.ajax({
            url: this._endpoints.create,
            method: 'POST',
            data: {
                name: conString.name,
                value: conString.value
            },
            success: function (data: cs.serverResultBase) {
                if (!data || !data.success)
                    throw new Error("Failed to add connection string!");
                _self.load(then);
            },
            error: function () {
                throw new Error("Failed to add connection string!");
            }
        });
    }

    public delete(conStringId: number, then: () => void = () => { }): void {
        var _self = this;
        $.ajax({
            url: this._endpoints.delete,
            method: 'POST',
            data: conStringId,
            success: function (data: cs.serverResultBase) {
                if (!data || !data.success)
                    throw new Error("Failed to delete connection string!");
                _self.load(then);
            },
            error: function () {
                throw new Error("Failed to delete connection string!");
            }
        });
    }

    public update(conString: cs.connectionString, then: () => void = () => { }): void {
        var _self = this;
        $.ajax({
            url: this._endpoints.update,
            method: "POST",
            data: conString,
            success: function (data: cs.serverResultBase) {
                if (!data || !data.success)
                    throw new Error("Failed to update connection string!");
                _self.load(then);
            },
            error: function () {
                throw new Error("Failed to update connection string!");
            }
        });
    }
}

let ConnectionStringClient: connectionStringClient = new connectionStringClient();
export { ConnectionStringClient };

(() => {
    $(function () {
        var endpoints = ConnectionStringClient.Endpoints;
        var message = "ConnectionStringClient: the endpoint property '{prop}' has not been set.";
        u.Utilities.assert(endpoints.load.length>0,   message.replace('{prop}', 'load'));
        u.Utilities.assert(endpoints.create.length>0, message.replace('{prop}', 'create'));
        u.Utilities.assert(endpoints.delete.length>0, message.replace('{prop}', 'delete'));
        u.Utilities.assert(endpoints.update.length>0, message.replace('{prop}', 'update'));
    });
})();