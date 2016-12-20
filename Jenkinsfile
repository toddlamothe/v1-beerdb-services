#!groovy

node {
    stage('Containerize and Build') {
        echo '[Build #14]'
        echo 'Starting Containerize and Build...'
        bat 'docker build -t toddlamothe/beerdb-services C:/code/beerdb_services/'
        /* .. snip .. */
    }
    stage('Test') {
        echo 'Starting Test...'
        /* .. snip .. */
    }
    stage('Deploy') {
        echo 'Starting Deploy...'
        
        // Attempt to stop any instances of the running container before building.
        try {
            bat 'docker rm $(docker stop $(docker ps -a -q --filter ancestor=toddlamothe/beerdb-services --format="{{.ID}}"))'
        }
        catch(err) {
            echo err
        }

        bat 'docker run -d -p 8888:80 toddlamothe/beerdb-services'
    }
}


