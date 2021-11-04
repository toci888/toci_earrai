import { StyleSheet } from 'react-native';


export const Vendors_Inputs_Styles = StyleSheet.create({

    container: {
        display: 'flex',
        flexDirection: 'row',
    },
    vendorPickerCont: {
        width: '30%',
    },
    metricPickerCont: {
        width: '20%',
    },
    priceCont: {
        width: '32%',
    },
    okCont: {
        width: '18%',
    },
    priceFlex: {
        margin: 3,
    },
    inputStyle: {
        marginTop: 3,
        marginBottom: 3,
        height: 40,
        backgroundColor: '#ddd',
        borderColor: '#777',
        color: '#000',
        letterSpacing: 0.5,
        paddingTop: 3,
        paddingBottom: 3,
        paddingLeft: 5,
        fontSize: 14,
    },
    okFlex: {
        height: 40,
        marginTop: 6,
        backgroundColor: '#799',
    },
    ok: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },





    ComboView: {
        marginTop: 5,
        marginBottom: 5,
        marginLeft: 3,
        marginRight: 3,
    },
    ComboPicker: {
        height: 40,
        backgroundColor: '#c1c1d2',
        borderWidth: 1,
        borderColor: '#c7c7c7',
        paddingLeft: 10
    },
    CombiItem: {
        backgroundColor: 'red',
        color: 'yellow'
    },


})