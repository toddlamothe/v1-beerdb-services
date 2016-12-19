node {
    stage('Containerize and Build') {
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
        bat 'docker run -d -p 8888:80 toddlamothe/beerdb-services'
    }
}


