/// <reference path="c:/Projects/EZReporting/Webserver/Scripts/typings/jQuery/jQuery.d.ts" />

import 'jQuery';
import * as cs from './ConnectionStringModels';

export class connectionStringClient {
    private _connectionStrings: Array<cs.connectionString>;

    private _endpoints: cs.connectionStringEndpoints;

    public setEndpoints(endpoints: cs.connectionStringEndpoints) {
        this._endpoints = endpoints;
    }

    public load(endpoint: string): void {
        $.ajax({
            url: this._endpoints.load,
            method: 'GET',
            success: function (data: cs.connectionStringsServerResult) {
                if (!data || !data.success)
                    throw new Error("Failed to receive connection string data.");
                this._connectionStrings = data.connectionStrings;
            },
            error: function () {
                throw new Error("Failed to receive connection string data.");
            }
        });
    }

    public getConnectionStrings(): cs.connectionString[] {
        return this._connectionStrings;
    }

    public add(conString: cs.connectionString): void {
        $.ajax({
            url: this._endpoints.add,
            method: 'POST',
            data: conString,
            success: function (data: cs.serverResultBase) {
                if (!data || !data.success)
                    throw new Error("Failed to add connection string!");
            },
            error: function () {
                throw new Error("Failed to add connection string!");
            },
            complete: function () {
                this.load();
            }
        });
    }

    public delete(conStringId: number): void {
        $.ajax({
            url: this._endpoints.delete,
            method: 'POST',
            data: conStringId,
            success: function (data: cs.serverResultBase) {
                if (!data || !data.success)
                    throw new Error("Failed to delete connection string!");
            },
            error: function () {
                throw new Error("Failed to delete connection string!");
            },
            complete: function () {
                this.load();
            }
        });
    }

    public update(conString: cs.connectionString): void {
        $.ajax({
            url: this._endpoints.update,
            method: "POST",
            data: conString,
            success: function (data: cs.serverResultBase) {
                if (!data || !data.success)
                    throw new Error("Failed to update connection string!");
            },
            error: function () {
                throw new Error("Failed to update connection string!");
            },
            complete: function () {
                this.load();
            }
        });
    }
}

let ConnectionStringClient: connectionStringClient = new connectionStringClient();
export default { ConnectionStringClient };