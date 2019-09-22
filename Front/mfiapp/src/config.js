
const dev = {    
    apiGateway: {
        URL_BASE: "http://localhost:91/"
    }
};

const prod = {    
    apiGateway: {
        URL_BASE: "http://localhost:91/"
    }
};

const configMFI = process.env.REACT_APP_STAGE === 'production'
    ? prod
    : dev;

export default {
    // Add common config values here
    ...configMFI
};