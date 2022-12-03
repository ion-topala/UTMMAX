export interface LoginResultModel {
  accessToken: string;
  refreshToken: string;
  tokenType: string;
  expiresIn: number;
  refreshTokenExpirationTime: Date | string;
}

export interface RegisterUserModel {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  birthday: Date | string;
  gender: Gender;
}

export enum Gender {
  None = 0,
  Male = 1,
  Female = 2
}

export interface UserModel {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  birthday: Date | string;
  gender: Gender;
}

export interface LoginModel {
  email: string;
  password: string;
}

export interface LoginByRefreshTokenModel {
  refreshToken: string;
}
