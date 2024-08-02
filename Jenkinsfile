pipeline {
    agent any

    parameters {
        choice(name: 'BUILD_TARGET', choices: ['Windows', 'Android'], description: 'Select the build target')
    }

    stages {
        stage('Build') {
            steps {
                script {

                    def unityExecutable = "\"C:\\Program Files\\Unity\\Hub\\Editor\\2021.3.22f1\\Editor\\Unity.exe\""
                    def unityBuildCmd
                    def buildResult
                    print("unitypath from env:" + env.UnityPath)
                    if (params.BUILD_TARGET == 'Windows') {
                        unityBuildCmd = "${unityExecutable} -batchmode -nographics -projectPath $workspace -buildWindowsPlayer Builds\\Windows\\Asteroids.exe -logFile Builds\\Windows\\build.log -quit"
                        buildResult = bat(script: unityBuildCmd, returnStatus: true)
                    } else if (params.BUILD_TARGET == 'Android') {
                        unityBuildCmd = "${unityExecutable} -batchmode -nographics -projectPath $workspace -executeMethod BuildScript.PerformAndroidBuild -logFile build.log -quit"
                        buildResult = bat(script: unityBuildCmd, returnStatus: true)
                    } else {
                        error("Invalid build target selected: ${params.BUILD_TARGET}")
                    }
                }
            }
        }
    }
}