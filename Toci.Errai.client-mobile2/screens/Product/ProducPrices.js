import React from 'react'
import { View } from 'react-native'
import { Text } from 'react-native-paper'
import { productDetails as pd } from '../../styles/productDetails'

export default function ProductPrices(props) {
    return (

        <View>
            <Text style={{padding: 15, fontSize: 17, width: '100%', textAlign: 'center'}} >
                Prices
            </Text>
            {
                props?.product?.prices?.map( (v, k) => {
                    return(
                        <View key={k} style={pd.inlineContainer}>
                            <Text style={[pd.inlineItem, pd.inlineItemLeft]}>
                                { (parseFloat(v.price) ).toFixed(2)} £
                            </Text>
                            <Text style={[pd.inlineItem, pd.inlineItemRight]}>
                                {v.valuation }
                            </Text>
                        </View>
                    )
                })
            }
        </View>
    )
}
