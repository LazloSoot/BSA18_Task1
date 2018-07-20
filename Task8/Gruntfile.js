module.exports = function(grunt) {

  require("load-grunt-tasks")(grunt);
    grunt.initConfig({

        watch: {

            options: {

                livereload: 8585

            },

            css: {

                files: ['assets/**/*.less'],

                tasks: ['less', 'autoprefixer', 'csso']

            },

            html: {

                files: ['**/*.html']

            },

            js: {

                files: ['assets/js/**/*.js'],

                tasks: ['uglify']

            },
          
          images: {
              
                files: ['assets/img/**/*.jpg', 'assets/img/**/*.png', 'assets/img/**/*.gif'],
            
                tasks: ['imagemin']
            
          },
          
          sprites: {
            
            files: ['assets/img/icons/*.svg'],
            
            tasks: ['symbols']
          }

        },
        
        postcss: {
          style: {
            options: {
              processors: [
                require("css-mqpacker")({
                  sort: true
                })
              ]
            },
            src: "dist/css/*.css"
          }
        },
      
        less: {

            development: {

                options: {

                    paths: ["assets/less"]

                },

                files: {
                  "dist/css/style.css": "assets/less/style.less"

                }

            }

        },

        autoprefixer: {

            options: {

                browsers: ['last 2 versions', 'ie 9']

            },

            your_target: {

                src: 'dist/css/style.css',

                dest: 'dist/css/style.css'

            }

        },

        csso: {

            compress: {

                options: {

                    report: 'gzip'

                },

                files: {

                    'dist/css/style.min.css': ['dist/css/style.css']

                }

            }

        },
        
        imagemin: {
          images: {
            options: {
              optimizationLevel: 3
            },
            files: [{
              expand: true,
              cwd: "assets/img/",
              src: ["**/*.{png,jpg,gif}"],
              dest: "dist/img/"
            }]
          }
        },
      
        svgmin: {
          symbols: {
            files: [{
              expand: true,
              src: ["assets/img/icons/*.svg"]
            }]
          }
        },
        
        svgstore: {
          options: {
            prefix: "icon-",
            svg: {
              style: "display: none"
            }
          },
          symbols: {
            files: {
              "dist/img/symbols.svg": ["assets/img/icons/*.svg"]
            }
          }
        },

        uglify: {

            options: {

                mangle: false

            },

            my_target: {

                files: {

                    'dist/js/main.min.js': ['assets/js/**/*.js']

                }

            }

        }

    });

    grunt.registerTask('build', ['less', 'autoprefixer', 'postcss', 'csso', 'uglify','imagemin', 'symbols']);
  
    grunt.registerTask('build--watch', ['less', 'autoprefixer', 'postcss', 'csso', 'uglify','imagemin', 'symbols', 'watch']);
    
    grunt.registerTask('symbols', ['svgmin','svgstore']);
};
