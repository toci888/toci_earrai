import React from 'react'
import { Text, View } from 'react-native'
import { productDetails as pd } from '../styles/productDetails'


export default function Product_UtilTable(props) {
    console.log(props)
    return (
        <View style={{marginBottom: 55}}>
            <View>
                <Text style={{padding: 15, fontSize: 17, width: '100%', textAlign: 'center'}}> {props.name} </Text>
            </View>

            {
                props.details && Object.keys(props.details).map( (value, key) => {
                    if(props.details[value] == null) return
                    return (
                        <View key={key} style={pd.inlineContainer}>
                            <Text  style={[pd.inlineItem, pd.inlineItemLeft]}>
                                {value}
                            </Text>
                            <Text style={[pd.inlineItem, pd.inlineItemRight]}>
                                {props.details[value]}
                            </Text>
                        </View>
                    )
                } )
            }








            {/* <View>
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

            </View> */}
        </View>
    )
}
