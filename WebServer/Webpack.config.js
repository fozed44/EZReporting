/// <binding BeforeBuild='Run - Development' />

var config = {
    context: __dirname + '/Scripts',
    resolve: {
        modules: [__dirname, 'node_modules']
    },
    module: {}
};

var connectionStringConfig = Object.assign({}, config, {
    entry: './ConnectionString/src/index.js',
    output: {
        path: __dirname + '/Scripts/ConnectionString/dist',
        filename: 'bundle.js'
    }
});

module.exports = [
    connectionStringConfig
];