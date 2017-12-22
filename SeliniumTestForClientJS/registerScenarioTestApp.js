
const {Builder, By, until} = require('selenium-webdriver');
let driver = new Builder().forBrowser('firefox').build();

//go to this address
driver.get('file:///C:/Users/mohayas/Documents/GitHub/LeKioskFullStackTest/ClientJS/index.html');

// try to register with data invalid then correct the data so you can register with success

signupFailed();

//wait for some time (5 seconds)
var waitTill = new Date(new Date().getTime() + 5 * 1000);
while(waitTill > new Date()){}

signupWithSucces();	    



//signup faild scenario because of the password didn't match
function signupFailed() {
	//click on register
	driver.findElement(By.id('register-form-link')).click();
	//wait for the form to fade in
	driver.wait(until.elementLocated(By.id('register-form')), 60000);
	//fill the fields
	driver.findElement(By.id('firstname')).sendKeys('newUserFirstName');
	driver.findElement(By.id('lastname')).sendKeys('newUserFirstName');
	driver.findElement(By.id('email')).sendKeys('new.user@email.com');
	driver.findElement(By.id('password')).sendKeys('pppppppp');
	driver.findElement(By.id('confirm-password')).sendKeys('a');	
	//submit
	driver.findElement(By.id('register-submit')).click();
    console.log('signup faild');}

//signup successeful scenario
function signupWithSucces() {
	
	//confirm password correctly
	driver.findElement(By.id('confirm-password')).clear();
	driver.findElement(By.id('confirm-password')).sendKeys('pppppppp');
	//submit
	driver.findElement(By.id('register-submit')).click();
    console.log('signup successeded');
}
