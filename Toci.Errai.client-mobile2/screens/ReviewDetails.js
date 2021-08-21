import React from 'react'
import { View, Text } from 'react-native'

export default function ReviewDetails( { navigation} ) {
    return (
        <View>
            <Text>Hej Details</Text>
            <Text> { navigation.getParam('name')}   </Text>
        </View>
    )
}
