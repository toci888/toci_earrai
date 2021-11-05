import React, { useEffect, useState } from 'react'
import { Text, View } from 'react-native'
import { getCommisions } from '../shared/RequestConfig'
import { productDetails as pd } from '../styles/productDetails'

export default function Product_Commisions(props) {

    const [CommisionsHook, setCommisionsHook] = useState([])
    console.log(props)
    useEffect(() => {
        if(isNaN(props.price) || props.price == "") return
        fetch(getCommisions(props.productId, props.price))
        .then( response_ => response_.json())
        .then( response_ => {
            console.log(response_)
            setCommisionsHook(response_)
        })
        .catch(error_ => console.log(error_))

    }, [])


    return (
        <View style={{marginBottom: 55, backgroundColor: '#e5e5e5'}}>
            <View>
                <Text style={{padding: 15, fontSize: 17, width: '100%', textAlign: 'center', fontWeight: 'bold'}}>
                    Commisions
                </Text>
            </View>

            {
                CommisionsHook && Object.keys(CommisionsHook).map( (value, key) => {
                    console.log(key)
                    return (
                        <View key={key} style={pd.inlineContainer}>
                            <Text style={[pd.inlineItem, pd.inlineItemLeft, pd.bold]}>
                                {CommisionsHook[value]?.toFixed(2)} £
                            </Text>
                            <Text style={[pd.inlineItem, pd.inlineItemRight, pd.bold]}>
                                {value}
                            </Text>
                        </View>
                    )
                } )
            }

        </View>
    )
}
