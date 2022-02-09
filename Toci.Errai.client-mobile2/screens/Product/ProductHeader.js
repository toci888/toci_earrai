import React, { useEffect, useState } from 'react'
import { View, Text } from 'react-native'
import AppUser from '../../shared/AppUser'
import { getProductUrl } from '../../shared/RequestConfig'
import RestClient from '../../shared/RestClient';

export default function ProductHeader(props) {

    const [ProductCode, setProductCode] = useState("")
    let restClient = new RestClient();

    useEffect( () => {

        const id = AppUser.getProductId()

        restClient.GET(getProductUrl(id)).then(x => { 
            console.log("getProductUrl:"); 
            console.log(x); 
            setProductCode(x.product.description);
        }).catch(e => console.log(e));

    }, [])
    return (

        <View>
            <Text>
                {props.title}
            </Text>
            <Text>
                {ProductCode}
            </Text>
        </View>
    )
}
