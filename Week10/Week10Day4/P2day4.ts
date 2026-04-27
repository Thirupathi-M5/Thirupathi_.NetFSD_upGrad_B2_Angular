// Problem -2: User Notification System using TypeScript Functions

// 1. Function with Required Parameters
function getWelcomeMessage(name: string): string {
    return `Welcome ${name}!`;
}


// 2. Optional Parameters
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User Name: ${name}, Age: ${age}`;
    } else {
        return `User Name: ${name}`;
    }
}


// 3. Default Parameters
function getSubscriptionStatus(
    name: string,
    isSubscribed: boolean = false
): string {
    return isSubscribed
        ? `${name} is subscribed.`
        : `${name} is not subscribed.`;
}


// 4. Return Type Boolean
function isEligibleForPremium(age: number): boolean {
    return age >= 18;
}


// 5. Arrow Functions
const getAccountUpdate = (name: string): string => {
    return `Account updated successfully for ${name}.`;
};

const getAlertMessage = (message: string): string =>
    `Alert: ${message}`;


// 6. Lexical this
const notificationService = {
    appName: "MyAngularApp",

    showNotification: (): string => {
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