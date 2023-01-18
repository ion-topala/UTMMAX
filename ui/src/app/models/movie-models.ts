export interface MovieFilterModel {
  type: MovieType;
  limit: number;
}

export enum MovieType {
  Movie = 1,
  TvSeries = 2,
  Cartoons = 3,
  Anime = 4,
  AnimatedSeries = 5,
}

export interface GenericRatingModel {
  kp: number;
  imdb: number;
  filmCritics: number;
  russianFilmCritics: number;
  await: number;
}

export interface VotesModel extends GenericRatingModel {
}

export interface RatingModel extends GenericRatingModel {
}

export interface MovieResultModel {
  id: number | null;
  movieType: MovieType;
  description: string | null;
  year: number | null;
  alternativeName: string | null;
  enName: string | null;
  movieLength: number | null;
  shortDescription: string | null;
  logoUrl: string;
  posterUrl: string;
  posterPreviewUrl: string;
  votes: VotesModel;
  rating: RatingModel;
}

export interface Budget {
  id: string;
  value: number;
  currency: string;
}

export interface Country {
  name: string;
}

export interface ExternalId {
  kpHd: any;
  imdb: string;
  tmdb: number;
  id: string;
}

export interface Fact {
  value: string;
  type: string;
  spoiler: boolean;
}

export interface Genre {
  name: string;
}

export interface BaseMovieModel {
  _Id: string;
}

export interface Logo extends BaseMovieModel {
  url: string;
}

export interface MovieDetailsModel {
  id: number;
  logo: Logo;
  poster: Poster;
  rating: RatingModel;
  votes: VotesModel;
  videos: Videos;
  budget: Budget;
  premiere: Premiere;
  status: string;
  productionCompanies: ProductionCompany[];
  spokenLanguages: SpokenLanguage[];
  type: string;
  name: string;
  description: string;
  slogan: string;
  year: number;
  facts: Fact[];
  genres: Genre[];
  countries: Country[];
  seasonsInfo: SeasonsInfo[];
  persons: Person[];
  typeNumber: MovieType;
  alternativeName: string;
  enName: any;
  names: MovieName[];
  ageRating: any;
  movieLength: number;
  ratingMpaa: any;
  updatedAt: string;
  shortDescription: any;
  technology: Technology;
  ticketsOnSale: boolean;
  sequelsAndPrequels: SequelsAndPrequel[];
  similarMovies: SimilarMovie[];
  releaseYears: ReleaseYear[];
  top10: any;
  top250: any;
  createDate: string;
}

export interface MovieName {
  name: string;
}

export interface Person {
  id: number;
  photo: string;
  name: string;
  enName: string;
  enProfession: string;
}

export interface Poster extends BaseMovieModel {
  url: string;
  previewUrl: string;
}

export interface Premiere {
  id: string;
  country: string;
  world: string;
  digital: string;
}

export interface ProductionCompany {
  name: string;
  url: string;
  previewUrl: string;
}

export interface ReleaseYear {
  start: number;
  end: number;
  id: string;
}

export interface SeasonsInfo {
  number: number;
  episodesCount: number;
}

export interface SequelsAndPrequel {
  id: string;
}

export interface SimilarMovie {
  id: string;
  name: string;
  enName: string;
  alternativeName: string;
  poster: Poster;
}

export interface SpokenLanguage {
  name: string;
  nameEn: string;
}

export interface Technology {
  id: string;
  hasImax: boolean;
  has3D: boolean;
}

export interface Trailer {
  id: string;
  url: string;
  name: string;
  site: string;
  size: number | null;
  type: string;
}

export interface Videos {
  trailers: Trailer[];
}
