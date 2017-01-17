#!groovy

node {
  stage('Containerize and Build') {
    dir("${WORKSPACE}@script") {
      bat 'docker build -t toddlamothe/beerdb-services .'
    }
  }
  stage('Test') {
      /* .. snip .. */
  }
}
