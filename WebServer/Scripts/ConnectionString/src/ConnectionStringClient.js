/// <reference path="c:/Projects/EZReporting/Webserver/Scripts/typings/jQuery/jQuery.d.ts" />
import 'jQuery';
var connectionStringClient = (function () {
    function connectionStringClient() {
    }
    connectionStringClient.prototype.load = function (endpoint) {
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
    };
    connectionStringClient.prototype.getConnectionStrings = function () {
        return this._connectionStrings;
    };
    return connectionStringClient;
}());
export { connectionStringClient };
var ConnectionStringClient = new connectionStringClient();
export default { ConnectionStringClient: ConnectionStringClient };
//# sourceMappingURL=ConnectionStringClient.js.map