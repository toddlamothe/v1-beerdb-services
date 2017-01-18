#!groovy

node {
  stage('Containerize, Build and Deploy') {
    dir("${WORKSPACE}@script") {
      bat 'docker build -t toddlamothe/beerdb-services .'
    }
  }
  stage('Test') {
      /* .. snip .. */
  }
  stage('Deploy to Docker Hub') {
    bat 'docker login -u toddlamothe https://index.docker.io/v1/'
    bat 'docker push toddlamothe/beerdb-services'
  }
}
