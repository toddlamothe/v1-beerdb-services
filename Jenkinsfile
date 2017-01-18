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
    bat 'docker push toddlamothe/beerdb-services'
  }
}
