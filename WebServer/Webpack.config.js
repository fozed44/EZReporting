/// <binding BeforeBuild='Run - Development' />


var config = {
    context: __dirname + '/Scripts',
    resolve: {
        extensions: ["webpack.js", "web.js", ".ts", ".js"]
    },
    module: {
        loaders: [
            { test: /\.ts$/, loader: "ts-loader" }
        ]
    }
};

var connectionStringConfig = Object.assign({}, config, {
    entry: './ConnectionString/src/main.js',
    output: {
        path: __dirname + '/Scripts/ConnectionString/dist',
        filename: 'bundle.js'
    }
});

module.exports = [
    connectionStringConfig
];

