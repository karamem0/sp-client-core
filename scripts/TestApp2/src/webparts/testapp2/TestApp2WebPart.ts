import { Version } from '@microsoft/sp-core-library';
import { BaseClientSideWebPart } from '@microsoft/sp-webpart-base';

import styles from './TestApp2WebPart.module.scss';

export interface ITestApp2WebPartProps {
}

export default class TestApp2WebPart extends BaseClientSideWebPart<ITestApp2WebPartProps> {

  public render(): void {
    this.domElement.innerHTML = `<div class="${styles.testapp2}"></div>`;
  }

  protected onInit(): Promise<void> {
    return super.onInit();
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

}
