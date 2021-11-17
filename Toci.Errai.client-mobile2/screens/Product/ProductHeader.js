import React, { useEffect, useState } from 'react'
import { View, Text } from 'react-native'
import AppUser from '../../shared/AppUser'
import { getProductUrl } from '../../shared/RequestConfig'

export default function ProductHeader(props) {

    const [ProductCode, setProductCode] = useState("")

    useEffect( () => {

        const x = AppUser.getProductId()

        fetch(getProductUrl(x)).then(response_ => {
            return response_.json()
        }).then(response_ => { console.log(response_)
            setProductCode(response_.product.description)

        })

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
