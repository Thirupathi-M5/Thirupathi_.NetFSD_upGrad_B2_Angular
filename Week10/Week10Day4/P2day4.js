"use strict";
// Problem -2: User Notification System using TypeScript Functions
// 1. Function with Required Parameters
function getWelcomeMessage(name) {
    return `Welcome ${name}!`;
}
// 2. Optional Parameters
function getUserInfo(name, age) {
    if (age !== undefined) {
        return `User Name: ${name}, Age: ${age}`;
    }
    else {
        return `User Name: ${name}`;
    }
}
// 3. Default Parameters
function getSubscriptionStatus(name, isSubscribed = false) {
    return isSubscribed
        ? `${name} is subscribed.`
        : `${name} is not subscribed.`;
}
// 4. Return Type Boolean
function isEligibleForPremium(age) {
    return age >= 18;
}
// 5. Arrow Functions
const getAccountUpdate = (name) => {
    return `Account updated successfully for ${name}.`;
};
const getAlertMessage = (message) => `Alert: ${message}`;
// 6. Lexical this
const notificationService = {
    appName: "MyAngularApp",
    showNotification: () => {
        return `Notification from MyAngularApp`;
    }
};
// 7. Execution
console.log(getWelcomeMessage("Thiru"));
console.log(getUserInfo("Thiru", 22));
console.log(getUserInfo("Ram"));
console.log(getSubscriptionStatus("Thiru", true));
console.log(getSubscriptionStatus("Sai"));
console.log("Premium Eligible:", isEligibleForPremium(25));
console.log("Premium Eligible:", isEligibleForPremium(16));
console.log(getAccountUpdate("Thiru"));
console.log(getAlertMessage("Subscription expires soon"));
console.log(notificationService.showNotification());
