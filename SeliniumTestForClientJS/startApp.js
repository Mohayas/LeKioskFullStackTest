const {Builder, By, until} = require('selenium-webdriver');

let driver = new Builder()
    .forBrowser('firefox')
    .build();

driver.get('file:///C:/Users/mohayas/Documents/GitHub/LeKioskFullStackTest/ClientJS/index.html');
driver.findElement(By.id('login-email')).sendKeys('mo@yas.com');
driver.findElement(By.id('login-password')).sendKeys('aaa');
driver.findElement(By.id('login-submit')).click();
driver.findElement(By.id('signout')).click();
//wait 5 second a

// driver.wait(5000);