#!groovy

node {
    stage('Pull latest orchestration scripts') {
        def exists = fileExists '..\\beerdb-orchestration\\docker-compose.yml'

        if (exists) {
            echo 'Pulling latest orchestration files'
            dir('..\\beerdb-orchestration\\') {
                bat 'git pull'
            }
        } else {
            dir('..\\') {
                echo 'Cloning orchestration repo';
                bat 'git clone https://github.com/toddlamothe/beerdb-orchestration.git'
            }
        }
    }
    stage('Stop running service containers') {
      // Attempt to stop any instances of the running container before building.
      try {
        dir('..\\beerdb-orchestration\\') {
            /*bat 'docker-compose stop api'*/
        }
      }
      catch(err) {
          echo 'Error occurred attempting to stop api services:'
          echo err
      }

    }
    stage('Pull latest source code') {
      echo 'Current working directory:'
      def workspace = pwd()
      echo workspace
      echo 'Pulling latest source...'
      bat 'git pull'
    }
    stage('Containerize and Build') {
        bat 'docker build -t toddlamothe/beerdb-services C:/code/beerdb-services/'
        /* .. snip .. */
    }
    stage('Test') {
        /* .. snip .. */
    }
    stage('Deploy') {
        // Attempt to stop any instances of the running container before building.
        try {
            // bat 'docker rm $(docker stop $(docker ps -a -q --filter ancestor=toddlamothe/beerdb-services --format="{{.ID}}"))'
        }
        catch(err) {
            echo err
        }

        bat 'docker run -d -p 8888:80 toddlamothe/beerdb-services'
    }
}
