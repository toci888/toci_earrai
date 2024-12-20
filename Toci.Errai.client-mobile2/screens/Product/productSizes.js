import React from 'react'
import { View } from 'react-native'
import { Text } from 'react-native-paper'
import { productDetails as ps } from '../../styles/productDetails'

export default function ProductSizes(props) {
    return (

        <View style={{backgroundColor: '#e5e5e5'}}>
            <Text style={{padding: 15, fontSize: 17, width: '100%', textAlign: 'center'}} >
                Sizes
            </Text>
            {
                props?.product?.sizes?.map( (v, k) => {
                    return(
                        <View key={k} style={ps.inlineContainer}>
                            <View style={[ps.inlineItem, ps.inlineItemLeft]}>
                                <Text style={{textAlign: 'right'}}> {v.name} </Text>
                            </View>
                            <View style={[ps.inlineItem, ps.inlineItemRight]}>
                                <Text> {v.value} </Text>
                            </View>
                        </View>
                    )
                })
            }
        </View>
    )
}
