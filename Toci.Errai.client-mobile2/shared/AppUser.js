import AsyncStorage from '@react-native-community/async-storage'

export default class AppUser {

    static id = null

    static token = null

    static worksheetId = null

    static productId = null

    static savedIdArea = 1 // TODO

    static areas = null

    static apiData = {}

    static userData

    static getApiData = async () => AppUser.apiData

    static setApiData = data => { AppUser.apiData = data }

    static setUserData = data => { AppUser.userData = data }

    static setWorksheetId = worksheetId_ => { AppUser.worksheetId = worksheetId_ }

    static getWorksheetId = () => AppUser.worksheetId

    static setWProductId = productId_ => { AppUser.productId = productId_ }

    static getWProductId = () => AppUser.productId

    static setAreas = areas_ => { AppUser.areas = areas_ }

    static getAreas = () => AppUser.areas

    static setIdArea = idArea_ => { AppUser.savedIdArea = idArea_ }

    static getIdArea = () => AppUser.savedIdArea

    static getId = () => AppUser.userData.id

    static getToken = () => AppUser.token

    static logIn = (id_, token_ = null) => {
        AppUser.id = id_
        AppUser.token = token_
    }

    static logOut = () => {
        AppUser.id = null
        AppUser.token = null
    }

    static checkIfAlreadyExists = async () => {
        let x = JSON.parse(await AsyncStorage.getItem('AppUser'))
        console.log(x)
        return x ? x : false
    }

}