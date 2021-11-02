import React from 'react'
import { Text, View } from 'react-native'
import { productDetails as pd } from '../styles/productDetails'

export default function Product_UtilTable(props) {

    return (
        <View>
            <View>
                <Text style={{padding: 15, fontSize: 17, width: '100%', textAlign: 'center'}}> {props.name} </Text>
            </View>
            <View>
                { props.details?.map( (value, key) => {
                    return(
                        <View style={pd.inlineContainer}>
                            <Text style={pd.inlineItemLeft}>
                                {key}
                            </Text>
                            <Text style={pd.inlineItemRight}>
                                {value}
                            </Text>
                        </View>
                    )
                })}

            </View>
        </View>
    )
}
