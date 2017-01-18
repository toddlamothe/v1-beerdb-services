#!groovy

node {
  stage('Containerize, Build and Deploy') {
    dir("${WORKSPACE}@script") {
      // bat 'docker build -t toddlamothe/beerdb-services .'
      echo 'Build and push API Docker image using docker.build...'
      docker.build('toddlamothe/beerdb-services').push('latest')
    }
  }
}
