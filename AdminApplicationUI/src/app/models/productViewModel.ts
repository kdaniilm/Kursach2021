import { CharacteristicModel } from "./characteristicModel";
import { ImageModel } from "./ImageModel";
import { ProductModel } from "./productModel";

export class ProductViewModel {
    public productModel!: ProductModel;
    public charactristicModels!: Array<CharacteristicModel>;
    public productImages!: Array<ImageModel>;
}