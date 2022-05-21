<template>
<v-app>
    <v-container fluid fill-height>
        <v-row align-center justify-center>
        <v-col cols="4"></v-col>
        <v-col cols="4">
            <v-card class="elevation-12 justify-center">
                <v-app-bar dark color="primary">
                    <v-app-bar-nav-icon></v-app-bar-nav-icon>
                    <v-toolbar-title >Registeration Form</v-toolbar-title>
                </v-app-bar>

            <v-card-text>
                <form ref="form"  v-on:submit.prevent="register">
                    <v-row>
                        <v-col>
                            <v-text-field
                            v-model="form.name.firstname"
                            name="firstname"
                            label="firstname"
                            type="text"
                            required
                            ></v-text-field>
                        </v-col>

                        <v-col>
                            <v-text-field
                            v-model="form.name.fathername"
                            name="fathername"
                            label="fathername"
                            type="text"
                            required
                            ></v-text-field>
                        </v-col>

                        <v-col>
                            <v-text-field
                            v-model="form.name.familyname"
                            name="familyname"
                            label="familyname"
                            type="text"
                            required
                            ></v-text-field>
                        </v-col>
                    </v-row>

                    <v-text-field
                    v-model="form.username"
                    name="username"
                    label="username"
                    type="text"
                    class="data--required"
                    required
                    prepend-inner-icon="mdi-account-circle"
                    ></v-text-field>

                    <v-text-field
                    v-model="form.birthdate"
                    name="birthdate"
                    label="birthDate"
                    type="text" onfocus="(this.type='date')" onblur="(this.type='text')"
                    required
                    ></v-text-field>

                    <v-text-field
                    v-model="form.occupation"
                    name="occupation"
                    label="occupation"
                    type="text"
                    required
                    ></v-text-field>

                    <v-text-field
                    v-model="form.address"
                    name="address"
                    label="address"
                    type="text"
                    required
                    ></v-text-field>

                    <v-text-field
                    v-model="form.password"
                    name="password"
                    label="password"
                    required
                    class="data--required"
                    :rules="passwordRules"
                    prepend-inner-icon="mdi-lock"
                    @click:append="showPassword = !showPassword"
                    :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
                    :type="showPassword ? 'text' : 'password'"
                    ></v-text-field>

                    <v-card-actions>
                        <v-btn dark color="primary" style="min-width: 140px " @click="register">
                            Register
                        </v-btn>
                    </v-card-actions>
                </form>
            </v-card-text>
            </v-card>
        </v-col>
        </v-row>
    </v-container>
</v-app>
</template>

<script>
import { mapActions,mapGetters } from "vuex";
export default {
  name: 'Register-view',
  data() {
    return {
      showPassword: false,
      form: {
        name:{
            firstname:"",
            fathername: "",
            familyname:""
        },
        username:"",
        birthdate:"",
        occupation: "",
        address: "",
        password:"",
      },
      passwordRules: [
        (v) => !!v || "Password is required",
        (v) => (v && v.length >= 8) || "Password must have 8+ characters",
        (v) => /(?=.*[A-Z])/.test(v) || "Must have one uppercase character",
        (v) => /(?=.*\d)/.test(v) || "Must have one number",
        (v) => /([!@$%])/.test(v) || "Must have one special character [!@#$%]",
      ],
    }
  },
  computed:{
    ...mapGetters({user:"StateUser"}) 
  },
  methods: {
        ...mapActions(["Register"]),

      async register(){
        let form = {
            firstname: this.form.name.firstname,
            fathername: this.form.name.fathername,
            familyname: this.form.name.familyname,
            username: this.form.username,
            birthdate: this.form.birthdate,
            occupation: this.form.occupation,
            address: this.form.address,
            password: this.form.password
        }

        await this.Register(form);
        this.$router.push(`/user/${this.user.id}`);
      }
  },
}
</script>

<style scoped>
</style>