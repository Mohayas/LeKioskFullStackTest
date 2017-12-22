const {
    Builder, By, until
} = require('selenium-webdriver');
let driver = new Builder().forBrowser('firefox').build();
//go to this address
driver.get('file:///C:/Users/mohayas/Documents/GitHub/LeKioskFullStackTest/ClientJS/index.html');
// sign in with success then logout then try to sign in again with wrong credentials;
signinWithSucces();
signoutWithSucces();
signinFailed();
//signin successeful scenario
function signinWithSucces() {
        driver.wait(until.elementLocated(By.id('login-email')), 60000);
        driver.findElement(By.id('login-email')).sendKeys('mo@yas.com');
        driver.findElement(By.id('login-password')).sendKeys('aaa');
        driver.findElement(By.id('login-submit')).click();
        console.log('signin in successed');
    }
    //signin successeful scenario
function signinFailed() {
        driver.wait(until.elementLocated(By.id('login-email')), 60000);
        driver.findElement(By.id('login-email')).sendKeys('---_______---');
        driver.findElement(By.id('login-password')).sendKeys('really');
        driver.findElement(By.id('login-submit')).click();
        console.log('signin in successed');
    }
    ////signout successeful scenario
function signoutWithSucces() {
    driver.wait(until.elementLocated(By.id('signout')), 60000);
    driver.findElement(By.id('signout')).click();
    console.log('signout in successed');
}