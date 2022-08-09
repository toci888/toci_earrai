import React, { Component } from 'react'
import { checkConnected } from '../shared/isConnected';

export default class CacheModuleService extends Component {

    functionsToCallOffline = new Array();
    functionsToCallOnline = new Array();

    state = {
        connected: true
    }

    constructor()
    {
        setInterval(this.hasConnection, 3000);        
    }

    hasConnection() 
    {
        this.state.connected = checkConnected();

        functions = this.state.connected ? functionsToCallOnline : functionsToCallOffline;

        functions.forEach(element => {
            element();
        });
    }

    registerOnlineFunction(callback)
    {
        this.functionsToCallOnline.push(callback);
    }

    registerOfflineFunction(callback)
    {
        this.functionsToCallOffline.push(callback);
    }

    render() {
        return (<div></div>)
    }
}
