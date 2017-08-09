/// <reference path="~/node_modules/vue/dist/vue.js" />
/// <reference path="~/node_modules/jQuery/dist/jquery.js" />
/// <reference path="ConnectionStringClient.js" />


var j = require('jQuery');
//var v = require('vue');
import v from 'vue/dist/vue.js';
var c = require('./ConnectionStringClient.ts');

function setEndpoints() {
    c.ConnectionStringClient.setEndpoints({
        load:     $('#CONNECTION_STRINGS_LOAD_ENDPOINT').val(),
        create:   $('#CONNECTION_STRINGS_CREATE_ENDPOINT').val(),
        update:   $('#CONNECTION_STRINGS_UPDATE_ENDPOINT').val(),
        'delete': $('#CONNECTION_STRINGS_DELETE_ENDPOINT').val()
    });
}

var _instance = new v({
    el: "#app",
    data: {
        connectionStrings: [],
        selectedCreate: '',
        selectedDelete: ''
    },
    methods: {
        create: function() {
            c.ConnectionStringClient.add({
                Name: $('#inpCreateName').val(),
                Value: $('#inpCreateValue').val()
            }, 
                () => {
                    c.ConnectionStringClient.loadConnectionStrings(this.connectionStrings);
                }
            );
            $('#inpCreateName').val('');
            $('#inpCreateValue').val('');
        },
        del: function () {
            if(!this.selectedDelete)
                return;
            var selectedOption = this.connectionStrings.find((item) => item.pkID === this.selectedDelete);
            if(typeof selectedOption !== 'object')
                return;
            var id = selectedOption.pkID;
            c.ConnectionStringClient.delete({
                pkID: id
            },
                () => {
                    c.ConnectionStringClient.loadConnectionStrings(this.connectionStrings);
                }
            )
        }
    },
    created: function () {
        setEndpoints();
    },
    mounted: function () {
        c.ConnectionStringClient.load(
            () => {
                c.ConnectionStringClient.loadConnectionStrings(this.connectionStrings);
            }
        );
    }
});

