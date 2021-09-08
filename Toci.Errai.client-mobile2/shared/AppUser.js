import AsyncStorage from '@react-native-community/async-storage'

export default class AppUser {

    static id = null

    static token = null

    static savedIdArea = null

    static apiData = []

    static userData

    static getApiData = async () => {
        return AppUser.apiData
        //return AsyncStorage.getItem('allData')
    }

    static setApiData = (data) => {
        AppUser.apiData = data
        //AsyncStorage.setItem('allData', JSON.stringify(data))
    }

    static setUserData = (data) => {
        AppUser.userData = data
        //AsyncStorage.setItem('userData', JSON.stringify(data))
    }

    static setIdArea = (idArea_) => { AppUser.savedIdArea = idArea_ }

    static getIdArea = () => AppUser.savedIdArea

    static getId = () => AppUser.id

    static getToken = () => AppUser.token

    static logIn = (id_, token_ = null) => {
        AppUser.id = id_
        AppUser.token = token_

        //AsyncStorage.setItem('AppUser', JSON.stringify({ id: id_, token: token_ }) )
    }

    static logOut = () => {
        AppUser.id = null
        AppUser.token = null

        /*AsyncStorage.removeItem('AppUser', error => {
            console.log(error);
        }).then(x => {
            console.log(x)
            console.log("USER REMOVED");
        })*/

    }

    static checkIfAlreadyExists = async () => {

        //let x = await AsyncStorage.getItem('AppUser')
        //x = JSON.parse(x)
        //console.log(x)
        //return x ? x : false
        return true

    }

}