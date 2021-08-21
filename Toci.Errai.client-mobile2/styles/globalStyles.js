import { StyleSheet } from 'react-native';

export const globalStyles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#ddd',
        marginTop: 25,
    },
    header: {
        backgroundColor: 'yellow',
        paddingTop: 15,
        paddingBottom: 15,
    },
    content: {
        backgroundColor: 'white',
        borderBottomColor: 'red',
        borderBottomWidth: 2
    },
    item: {
        backgroundColor: 'blue',
        color: '#ccc',
        borderBottomColor: 'rgb(204, 204, 204)',
        paddingTop: 10,
        paddingBottom: 10,
        borderBottomWidth: 1,
    },
    inputStyle: {
        borderWidth: 1,
        backgroundColor: '#ddd',
        borderColor: '#777',
        paddingTop: 25,
        paddingBottom: 25,
    }



});