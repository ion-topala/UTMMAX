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
