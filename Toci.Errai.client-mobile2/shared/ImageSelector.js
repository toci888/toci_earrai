
export const imagesManager = {
    1: {
        url: require('./../assets/pltSheetPL.png')
    },
    2: {
        url: require('./../assets/pltSheetPLCHQ.png')
    },

    7: {
        url: require('./../assets/mshMSH.png')
    },
    8: {
        url: require('./../assets/mshEX_MET.png')
    },
    9: {
        url: require('./../assets/RHS_SHS.png')
    },
    10: {
        url: require('./../assets/RHS_RHS.png')
    },

    11: {
        url: require('./../assets/chanPFC.png')
    },
    12: {
        url: require('./../assets/chanUB.png')
    },
    13: {
        url: require('./../assets/chanUC.png')
    },
    14: {
        url: require('./../assets/chanIPE.png')
    },
    15: {
        url: require('./../assets/anglesT_EA.png')
    },
    16: {
        url: require('./../assets/anglesT_UA.png')
    },




    18: {
        url: require('./../assets/TubeCHS_CHS.png')
    },
    19: {
        url: require('./../assets/TubeCHS_GCHS.png')
    },
    20: {
        url: require('./../assets/FLTS_FL.png')
    },



    22: {
        url: require('./../assets/Rnds_RB_BLK.png')
    },
    23: {
        url: require('./../assets/Rnds_RB_BRI.png')
    },
    24: {
        url: require('./../assets/Rnds_SQ_BLK.png')
    },
    26: {
        url: require('./../assets/Rnds_HB.png')
    },

}


export const imagesForWorksheet = {
    1: [1,2,3,4], //plt sheet
    2: [5,6], // alum
    3: [7,8], // mesh   
    4: [11,12,13,14], // chan 
    5: [18,19], //tube chs
    6: [20], // flts
    7: [15,16], // angles + t
    8: [22,23,24,26], // rnds
    9: [9,10], //rhs 
}


/*export class ImageSelector {


    static imageDict = {

        1: { img: 'pltSheetPL.png'},

        7: { img: 'mshMSH.png'},
        8: { img: 'mshEX_MET.png'},

        11: { img: 'chanPFC.png'},
        12: { img: 'chanUB.png'},
        13: { img: 'chanUC.png'},
        14: { img: 'chanIPE.png'},

    }

    static getImgByCategory(categoryId) {
        return ImageSelector.imageDict[categoryId]?.img
    }

}*/