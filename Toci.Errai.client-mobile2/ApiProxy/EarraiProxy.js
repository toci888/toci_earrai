import { Component } from 'react';
import {environment} from '../environment';
import RestClient from '../shared/RestClient';

export default class EarraiProxy extends Component
{
    
    constructor(props) 
    {
        super(props);
        //this.abc = this.abc.bind(this);
    }

    QueryApi = (uri, verb, headers, body) => 
    {
        let restClient = new RestClient();
        console.log(uri);

        
        let response = fetch(environment.apiUrl + uri, {
            method: verb,
            headers: headers,
            body: body
        });

        console.log(response);

        let json = response.response.json();
        
        console.log(json);

        return json;
    }
}
