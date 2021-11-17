import React, { useEffect, useState } from 'react'
import { View, Text } from 'react-native'
import AppUser from './AppUser'

export default function Header(props) {

    const [Counter, setCounter] = useState(0)

    useEffect( () => {

        const x = AppUser.getProductId()
        console.log(x)
        console.log(Counter)

    }, [])
    return (

        <View>
            <Text>
                {props.title}
            </Text>
        </View>
    )
}
