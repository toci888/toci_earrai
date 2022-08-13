import { StyleSheet } from 'react-native';

export const Product_AreaQuantityInputsStyle = StyleSheet.create({

    ComboView: {
        marginTop: 5,
        marginBottom: 5,
        marginLeft: 15,
        marginRight: 15,
    },
    ComboPicker: {
        height: 50,
        backgroundColor: '#c1c1d2',
        borderWidth: 1,
        borderColor: '#c7c7c7',
        paddingLeft: 10
    },
    CombiItem: {
        backgroundColor: 'red',
        color: 'yellow'
    },



    DimensionsView: {
        marginLeft: 15,
        marginRight: 15,
    },

    dimensionContainer:{
        flexDirection: 'row',
        marginBottom: 5,
    },
    labelFlex:{
        width: '16%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#799',
    },
    labelLetter:{
        color: 'white',
        fontSize: 17,
        fontWeight: 'bold',
    },
    inputFlex: {
        width: '90%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        paddingLeft: 10,
        fontSize: 17,
        width: '100%',
    },

})