<template>
<v-app>
    <v-container>
            <v-row align-center justify-center>
                <v-col cols="3"></v-col>
                <v-col cols="8">
                    <v-card raised class="mx-1 mb-2 cardContainer">
                    <div class="d-flex align-center pa-3 mb-2 title-bg font-weight-bold">
                        <span>My Profile</span>
                    </div>

                    <v-card-content class="pa-2">
                        <v-col cols="12" class="dataTitle mb-3">
                            General Data
                        </v-col>

                        <v-row class="my-1">
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Firstname:
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="1" lg="1" class="ms-3">
                                {{ user.firstname }}
                            </v-col>
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Fathername: 
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="1" lg="1" class="ms-3">
                                {{ user.fathername }}
                            </v-col>
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Familyname: 
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="1" lg="1" class="ms-3">
                                {{ user.familyname }}
                            </v-col>
                        </v-row>
                        <v-divider></v-divider>
                        <v-row class="my-1">
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Username:
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="6" lg="6" class="ms-3">
                                {{ user.username }}
                            </v-col>
                        </v-row>
                        <v-divider  class="mb-5"></v-divider>

                        <v-col cols="12" xs="12" sm="12" md="12" lg="12" class="dataTitle mb-3">
                            Personal Data
                        </v-col>

                        <v-row class="my-1">
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Birth Date:
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="1" lg="1" class="ms-3">
                                {{ user.birthdate }}
                            </v-col>
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Occupation: 
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="1" lg="1" class="ms-3">
                                {{ user.occupation }}
                            </v-col>
                            <v-col cols="5" xs="5" sm="5" md="2" lg="2" class="titleField ms-3">
                                Address: 
                            </v-col>
                            <v-col cols="6" xs="6" sm="6" md="1" lg="1" class="ms-3">
                                {{ user.address }}
                            </v-col>
                        </v-row>

                        <v-card-actions class="my-3 d-flex justify-end justify-xs-start" dense>                       
                            <v-btn @click="Back" raised class="mx-1 my-1 " color='primary'>
                                Back
                            </v-btn>
                            <v-btn @click="resetPassword" outlined raised class="mx-12 my-1 " color='primary'>
                                Reset Password
                            </v-btn>
                        </v-card-actions>
                    </v-card-content>
                    </v-card>
                </v-col>
            </v-row>
    </v-container>
</v-app>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: 'User-view',
  computed:{
    ...mapGetters({user:"StateUser"}) 
  },
  methods:{
    Back() {
        this.$router.push({name: 'register'})
    },
    resetPassword() {
    },
  }
}
</script>

<style  scoped>

.title-bg {
    border-style: solid;
    border-width: 1px;
    background-color: #59A1FC;
    color: #FFFFFF !important;
  }

 .cardContainer {
    border-radius: 5px !important;
  }

.titleField {
  font-weight: bold;
  font-size: 15px !important;
  color: #041f3b !important;
}

.dataTitle {
    color: #1A77D2 !important;
    font-weight: bold !important;
    font-size: 1.2rem !important;
    background: #fff !important;
  }
</style>