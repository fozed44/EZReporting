/// <reference path="~/node_modules/vue/dist/vue.js" />
/// <reference path="~/node_modules/jQuery/dist/jquery.js" />
/// <reference path="ConnectionStringClient.js" />


var j = require('jQuery');
//var v = require('vue');
import v from 'Vue';
var c = require('./ConnectionStringClient.ts');

function setEndpoints() {
    c.ConnectionStringClient.setEndpoints({
        load:     $('#CONNECTION_STRINGS_LOAD_ENDPOINT').val(),
        create:   $('#CONNECTION_STRINGS_CREATE_ENDPOINT').val(),
        update:   $('#CONNECTION_STRINGS_UPDATE_ENDPOINT').val(),
        'delete': $('#CONNECTION_STRINGS_DELETE_ENDPOINT').val()
    });
}

new v({
    el: "#app",
    data: function () {
        return {
            connectionStrings: []
        }
    },
    methods: {
        create: function() {
            c.ConnectionStringClient.add({
                name: $('inpCreateName').val(),
                value: $('inpCreateValue').val()
            });
        },
        'delete': function () {
            c.ConnectionStringClient.delete({

            })
        }
    },
    created: function () {
        setEndpoints();
        c.ConnectionStringClient.load($('#CONNECTION_STRINGS_ENDPOINT').val());
    }
});

