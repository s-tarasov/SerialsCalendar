module.exports = function (grunt) {
	grunt.loadNpmTasks("grunt-bower-task");
	grunt.loadNpmTasks("grunt-contrib-copy");

    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        }
    });
    
    grunt.registerTask("ts", ["tsd", "tslint", "tsng", "typescript:dev", "clean:tsng"]);
   
    grunt.registerTask("default", ["bower:install", "copy", "ts"]);

    grunt.registerTask("release", ["default", "uglify"]);

    require("grunt-ide-support")(grunt);
};