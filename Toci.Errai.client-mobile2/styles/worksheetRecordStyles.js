import { StyleSheet } from 'react-native';

export const worksheetRecord = StyleSheet.create({
    item: {
        borderTopWidth: 12,
        borderTopColor: '#807373',
        flexDirection: 'row'
    },
    listItem: {
        backgroundColor: 'white',
        color: 'black',
        paddingTop: 15,
        paddingBottom: 15,
        textAlign: 'center',
    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        textAlign: 'center',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        paddingLeft: 10,
        fontSize: 17,
        width: '100%',
    },
    updateButtonContainer: {
        width: '15%',
        height: '100%',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: '#5c5b61',
        color: 'white',
    },
    updateButton: {
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    container: {
        paddingTop: 55,
    },
    columns: {
        width: '60%',
    },
    value: {
        width: '40%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    grid: {
        width: '15%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    gridShort: {
        width: 40,
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },
    rowContainer: {
        flexDirection: 'row',
        borderBottomColor: 'black',
        borderBottomWidth: 1,
        paddingLeft: 0,
        paddingStart: 0
    },



    ComboPicker: {
        height: 50,
        backgroundColor: '#c1c1d2',
        borderWidth: 1,
        borderColor: '#c7c7c7',
        paddingLeft: 10
    },
    ComboView: {
        marginTop: 15,
        marginLeft: 15,
        marginRight: 15,
    },
    CombiItem: {
        backgroundColor: 'red',
        color: 'yellow'
    },


    DimensionsView: {
        //flexDirection: 'row',
       // display: 'flex',
        //marginRight: 25
        marginTop: 15,
        marginLeft: 15,
        marginRight: 15,
    },
    DimensionsInputContainerTwo: {
        width: '100%',
        //margin: 15,
        height: 50
    },
    DimensionsInputContainerOne: {
        width: '100%',
        //margin: 15,
        height: 50
    },
    QuantityInputContainer: {
        width: '100%',
        // marginBottom: 15,
        // marginLeft: 15,
        // marginRight: 15,
        height: 50
    },
    dimensionsInput: {
        backgroundColor: 'white',
        width: '100%',
        display: 'flex',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        fontSize: 17
    },


    vendorContainer: {
        flexDirection: 'row',
        display: 'flex',

    },
    vendorColumn: {
        padding: 5,
        width: '25%'
    },
    vendorColumnOK: {
        width: '100%',
        display: 'flex',
        height: 50,
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        backgroundColor: '#9999cc',
        fontSize: 18
    },
    vendorColumnInput: {
        backgroundColor: '#dddde6',
        width: '100%',
        display: 'flex',
        height: 50,
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        fontSize: 17
    },
    inputStyle: {
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 10,
        paddingBottom: 10,
        fontSize: 17,
        paddingLeft: 15
    }


})