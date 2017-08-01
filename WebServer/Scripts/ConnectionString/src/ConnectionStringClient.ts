/// <reference path="c:/Projects/EZReporting/Webserver/Scripts/typings/jQuery/jQuery.d.ts" />

import 'jQuery';
import * as cs from './ConnectionStringModels';

export class connectionStringClient {
    private _connectionStrings: Array<cs.connectionString>;

    public load(endpoint: string) {        
        $.ajax({
            url: endpoint,
            method: 'GET',
            success: function (data) {
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
}

let ConnectionStringClient: connectionStringClient = new connectionStringClient();
export default { ConnectionStringClient };