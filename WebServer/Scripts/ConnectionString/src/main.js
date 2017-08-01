/// <reference path="~/node_modules/vue/dist/vue.js" />
/// <reference path="~/node_modules/jQuery/dist/jquery.js" />
/// <reference path="ConnectionStringClient.js" />


var j = require('jQuery');
//var v = require('vue');
import v from 'Vue';
var c = require('./ConnectionStringClient.ts');

new v({
    el: "#app",
    data: function () {
        return {
            connectionStrings: []
        }
    },
    methods: {
    },
    created: function () {
        c.default.ConnectionStringClient.load($('#CONNECTION_STRINGS_ENDPOINT').val());
    }

});

