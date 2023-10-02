pipeline {
    agent any

    parameters {
        choice(name: 'BUILD_TARGET', choices: ['Windows', 'Android'], description: 'Select the build target')
    }

    stages {
        // stage('Checkout') {
        //     steps {
        //         // Checkout the code from the repository
        //         checkout scm
        //     }
        // }

        stage('Build') {
            steps {
                script {
                    def unityProjectPath = 'C:\\Users\\hehexd\\Asteroid'

                    dir(unityProjectPath) {
                        def unityExecutable = 'C:\\Programme\\Unity\\Hub\\Editor\\2021.3.22f1\\Editor\\Unity.exe'
                        def unityBuildCmd
                        def buildResult

                        if (params.BUILD_TARGET == 'Windows') {
                            unityBuildCmd = "${unityExecutable} -batchmode -nographics -projectPath \"C:\\Users\\hehexd\\Asteroids\" -buildWindowsPlayer \"C:\\Users\\hehexd\\Asteroids\\Builds\\Windows\\Asteroids.exe\" -logFile \"C:\\Users\\hehexd\\Asteroids\\Builds\\Windows\\build.log\" -quit"
                            buildResult = bat(script: unityBuildCmd, returnStatus: true)
                        } else if (params.BUILD_TARGET == 'Android') {
                            unityBuildCmd = "${unityExecutable} -batchmode -nographics -projectPath \"C:\\Users\\hehexd\\Asteroids\" -executeMethod BuildScript.PerformAndroidBuild -logFile \"C:\\Users\\hehexd\\Asteroids\\Builds\\Android\\build.log\" -quit"
                            buildResult = bat(script: unityBuildCmd, returnStatus: true)
                        } else {
                            error("Invalid build target selected: ${params.BUILD_TARGET}")
                        }

                        if (buildResult == 0) {
                            currentBuild.result = 'SUCCESS'
                        } else {
                            currentBuild.result = 'FAILURE'
                            error("Unity build failed with exit code ${buildResult}")
                        }
                    }
                }
            }
        }
    }
}