const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
module.exports = {
    context: path.resolve('./src/public'),
    devtool: "eval-source-map",
    entry: "./index.js",
    output: {
        path: path.resolve('./dist'),
        filename: '[name].bundle.js',
        sourceMapFilename: '[name].map',
        devtoolModuleFilenameTemplate: function (info) {
            return "file:///" + info.absoluteResourcePath;
        }
    },
    resolve: {
        extensions: [".js"],
        modules: [path.resolve('./src'), 'node_modules']
    },
    module: {
        loaders: [
            { test: /\.html$/, loader: "html" },
            // transpile ES6/7 to ES5 via babel
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: 'babel-loader'
            }
        ]
    },
    devServer: {
        contentBase: path.join(__dirname, 'dist'),
        inline: true,
        port: 4040
    },
    plugins: [
        new HtmlWebpackPlugin({
            title: 'Typescript Webpack Starter',
            template: '!!ejs-loader!src/views/index.html'
        })
    ]
};