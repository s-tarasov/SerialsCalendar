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
        },
        copy: {
		  img: {
		    cwd: 'Images',
		    src: '**/*',
		    dest: 'wwwroot/images',
		    expand: true
		  },
		  css: {
		    cwd: 'Styles',
		    src: '**/*',
		    dest: 'wwwroot/css',
		    expand: true
		  }
		}
    });

    grunt.registerTask("default", ["bower:install", "copy"]);
};