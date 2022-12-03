export interface ApiErrorModel {
  code: string;
  message: string;
  errors: any[];
}

export const ApiErrorCodes = {
  Forbidden: 'forbidden',
  Unauthorized: 'unauthorized',
  IdentityNotFound: 'user_not_found',
  InternalServerError: 'internal_server_error',
  InvalidData: 'invalid_data',
  OwnerNotFound: 'owner_not_found',
  ItemInUse: 'item_in_use',
  PictureNotFound: 'picture_not_found',
  Asset: {
    AssetNotFound: 'asset_not_found',
  },
  Category: {
    CategoryNotFound: 'category_not_found',
  },
  Manufacturer: {
    ManufacturerNotFound: 'manufacturer_not_found',
  },
  Contact: {
    ContactNotFound: 'contact_not_found',
    ContactNotEditable: 'contact_not_editable',
    ContactAlreadyExists: 'contact_already_exists',
  },
  AssetActivity: {
    AssetActivityNotFound: 'asset_activity_not_found',
  },
  Liability: {
    LiabilityNotFound: 'liability_not_found',
  },
  Register: {
    UserAlreadyExists: 'user_already_exists',
  },
  Authentication: {
    InvalidEmailOrPassword: 'invalid_email_or_password',
    InvalidRefreshToken: 'invalid_refresh_token',
    InvalidFirstNameOrLastNameOrPhone: 'invalid_firstname_or_lastname_or_phone',
  },
};
