#!groovy

node {
  stage('Containerize and Build') {
    dir("${WORKSPACE}@script") {
      bat 'docker build -t toddlamothe/beerdb-services .'
    }
  }
  stage('Deploy to Docker Hub') {
    bat 'docker push toddlamothe/beerdb-services'
  }
}
