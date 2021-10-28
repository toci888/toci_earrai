import React from 'react'
import { Text, View } from 'react-native'
import { productDetails as pd } from '../../styles/productDetails'


export default function ProductDetails(props) {
    return (
        <View>
            <View style={pd.inlineContainer}>
                <Text style={[pd.inlineItem, pd.inlineItemLeft, pd.smallSize]}>
                    Description
                </Text>
                <Text style={[pd.inlineItem, pd.inlineItemRight, pd.smallSize]}>
                    { props.product?.description }
                </Text>
            </View>
            <View style={pd.inlineContainer}>
                <Text style={[pd.inlineItem, pd.inlineItemLeft, pd.smallSize]}>
                    Account Reference
                </Text>
                <Text style={[pd.inlineItem, pd.inlineItemRight, pd.smallSize]}>
                    { props.product?.productaccountreference }
                </Text>
            </View>
        </View>
    )
}
