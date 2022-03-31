import React, { useEffect, useState } from 'react'
import { View, Text } from 'react-native'
import { modalStyles } from '../styles/modalStyles'


export default function Waiter(loading) {

    //const [Counter, setCounter] = useState(0)
   // const [loading, setloading] = useState(false)

    useEffect( () => {

      //  const x = AppUser.getProductId()


    }, [])

    if (loading)
    {
        return (<View style={modalStyles.tempContainer}>
        <Text style={modalStyles.tempText}>Loading ...</Text>
    </View>)
    }
}