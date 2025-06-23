using System.Linq;
using PriceParser.Domain.Product.Entities;

namespace PriceParser.ProcessExternalData.Product.Const
{
	public static class ProductEmailMessages
	{
		public static string GetWelcomePage(ProductEntity product, int productNumber)
		{
			var hostUrl = "http://localhost:3000";
			var shortenedTitle = product.Title.Length > 30 ? $"{product.Title[..30]}..." : product.Title;
			var shortenedCategory = product.Category.Length > 45 ? $"{product.Category[..45]}..." : product.Category;
			var shortenedDescription = product.Description.Length > 120 ? $"{product.Description[..120]}..." : product.Description;
			var currentPrice = product.PriceHistory.Last().Price;

			return $@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
				<html dir=""ltr"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">

				<head>
					<meta charset=""UTF-8"">
					<meta content=""width=device-width, initial-scale=1"" name=""viewport"">
					<meta name=""x-apple-disable-message-reformatting"">
					<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
					<meta content=""telephone=no"" name=""format-detection"">
					<title></title>
					<!--[if (mso 16)]>
					<style type=""text/css"">
					a {{text-decoration: none;}}
					</style>
					<![endif]-->
					<!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]-->
					<!--[if gte mso 9]>
				<xml>
					<o:OfficeDocumentSettings>
					<o:AllowPNG></o:AllowPNG>
					<o:PixelsPerInch>96</o:PixelsPerInch>
					</o:OfficeDocumentSettings>
				</xml>
				<![endif]-->
					<!--[if !mso]><!-- -->
					<link href=""https://fonts.googleapis.com/css2?family=Oswald:wght@500&display=swap"" rel=""stylesheet"">
					<link href=""https://fonts.googleapis.com/css2?family=Licorice&display=swap"" rel=""stylesheet"">
					<!--<![endif]-->
				</head>

				<body>
					<div dir=""ltr"" class=""es-wrapper-color"">
						<!--[if gte mso 9]>
							<v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
								<v:fill type=""tile"" color=""#ffffff""></v:fill>
							</v:background>
						<![endif]-->
						<table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"">
							<tbody>
								<tr>
									<td class=""esd-email-paddings"" valign=""top"">
										<table cellpadding=""0"" cellspacing=""0"" class=""esd-header-popover es-header"" align=""center"">
											<tbody>
												<tr>
													<td class=""esd-stripe"" align=""center"">
														<table bgcolor=""#ffffff"" class=""es-header-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color: #ffffff;"">
															<tbody>
																<tr>
																	<td class=""esd-structure es-p20t es-p10b es-p20r es-p20l"" align=""left"" esd-custom-block-id=""819780"">
																		<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																			<tbody>
																				<tr>
																					<td width=""560"" class=""es-m-p0r esd-container-frame"" valign=""top"" align=""center"">
																						<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																							<tbody>
																								<tr>
																									<td align=""center"" class=""esd-block-image"" style=""font-size: 0px;""><a target=""_blank"" href=""http://localhost:3000""><img class=""adapt-img"" src=""https://demo.stripocdn.email/content/guids/videoImgGuid/images/iconic_E3z.png"" alt=""Logo"" style=""display: block;"" title=""Logo"" width=""130""></a></td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</td>
																</tr>
															</tbody>
														</table>
													</td>
												</tr>
											</tbody>
										</table>
										<table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"">
											<tbody>
												<tr>
													<td class=""esd-stripe"" align=""center"">
														<table class=""es-content-body"" style=""border-left:2px solid #333333;border-right:2px solid #333333;border-bottom:2px solid #333333;background-color: #ffffff;"" width=""600"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#ffffff"" align=""center"">
															<tbody>
																<tr>
																	<td class=""esd-structure"" align=""left"" esd-custom-block-id=""819783"">
																		<table cellspacing=""0"" cellpadding=""0"" width=""100%"">
																			<tbody>
																				<tr>
																					<td class=""es-m-p0r esd-container-frame"" width=""596"" valign=""top"" align=""center"">
																						<table width=""100%"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#ffffff"" style=""background-color: #ffffff;"">
																							<tbody>
																								<tr>
																									<td align=""center"" class=""esd-block-text es-p30t es-p30b es-p40r es-p40l"" bgcolor=""#333333"">
																										<p style=""color: #ffffff; font-size: 20px;"">Price Parser</p>
																									</td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class=""esd-structure es-p30t es-p20r es-p20l esdev-adapt-off"" align=""left"" esd-custom-block-id=""819784"">
																		<table width=""556"" cellpadding=""0"" cellspacing=""0"" class=""esdev-mso-table"">
																			<tbody>
																				<tr>
																					<td class=""esdev-mso-td"" valign=""top"">
																						<table cellpadding=""0"" cellspacing=""0"" class=""es-left"" align=""left"">
																							<tbody>
																								<tr>
																									<td width=""230"" class=""es-m-p0r esd-container-frame"" align=""center"">
																										<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																											<tbody>
																												<tr>
																													<td align=""center"" class=""esd-block-spacer es-p30t es-p25b es-p20r es-p20l"" style=""font-size:0"">
																														<table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"">
																															<tbody>
																																<tr>
																																	<td style=""border-bottom: 1px solid #cccccc; background:none; height:1px; width:100%; margin:0px 0px 0px 0px;""></td>
																																</tr>
																															</tbody>
																														</table>
																													</td>
																												</tr>
																											</tbody>
																										</table>
																									</td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																					<td width=""20""></td>
																					<td class=""esdev-mso-td"" valign=""top"">
																						<table cellpadding=""0"" cellspacing=""0"" class=""es-left"" align=""left"">
																							<tbody>
																								<tr>
																									<td width=""56"" class=""esd-container-frame"" align=""center"">
																										<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																											<tbody>
																												<tr>
																													<td align=""center"" class=""esd-block-text es-p10"" bgcolor=""#efefef"">
																														<h1>{productNumber}</h1>
																													</td>
																												</tr>
																											</tbody>
																										</table>
																									</td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																					<td width=""20""></td>
																					<td class=""esdev-mso-td"" valign=""top"">
																						<table cellpadding=""0"" cellspacing=""0"" class=""es-right"" align=""right"">
																							<tbody>
																								<tr>
																									<td width=""230"" align=""center"" class=""esd-container-frame"">
																										<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																											<tbody>
																												<tr>
																													<td align=""center"" class=""esd-block-spacer es-p30t es-p25b es-p20r es-p20l"" style=""font-size:0"">
																														<table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"">
																															<tbody>
																																<tr>
																																	<td style=""border-bottom: 1px solid #cccccc; background:none; height:1px; width:100%; margin:0px 0px 0px 0px;""></td>
																																</tr>
																															</tbody>
																														</table>
																													</td>
																												</tr>
																											</tbody>
																										</table>
																									</td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</td>
																</tr>
																<tr>
																	<td class=""esd-structure es-p30t es-p20b es-p20r es-p20l"" align=""left"" esd-custom-block-id=""819787"" esdev-config=""h347"">
																		<!--[if mso]><table dir=""ltr"" cellpadding=""0"" cellspacing=""0""><tr><td><table dir=""rtl"" width=""556"" cellpadding=""0"" cellspacing=""0""><tr><td dir=""ltr"" width=""268"" valign=""top""><![endif]-->
																		<table cellpadding=""0"" cellspacing=""0"" class=""es-right"" align=""right"">
																			<tbody>
																				<tr>
																					<td width=""268"" class=""esd-container-frame es-m-p20b"" align=""left"">
																						<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																							<tbody>
																								<tr>
																									<td align=""center"" class=""esd-block-image"" style=""font-size: 0px;""><a target=""_blank"" href=""{product.Url}""><img src=""{product.ImageUrl}"" alt style=""display: block;"" width=""268"" class=""adapt-img p_image""></a></td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																		<!--[if mso]></td><td dir=""ltr"" width=""20""></td><td dir=""ltr"" width=""268"" valign=""top""><![endif]-->
																		<table cellpadding=""0"" cellspacing=""0"" class=""es-left"" align=""left"">
																			<tbody>
																				<tr>
																					<td width=""268"" class=""esd-container-frame"" align=""left"">
																						<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																							<tbody>
																								<tr>
																									<td align=""left"" class=""esd-block-image es-p25t es-p15b es-m-txt-c"" style=""font-size: 0px;""><img src=""https://tlr.stripocdn.email/content/guids/CABINET_8342f7b439312df98709d0093bab4dd1/images/group_279.png"" alt style=""display: block;"" height=""15""></td>
																								</tr>
																								<tr>
																									<td align=""left"" class=""esd-block-text es-p10b"">
																										<h1 class=""p_name"">{shortenedTitle}</h1>
																									</td>
																								</tr>
																								<tr>
																									<td align=""left"" class=""esd-block-image es-p10t es-p10b es-m-txt-c"" style=""font-size: 0px;""><img src=""https://tlr.stripocdn.email/content/guids/CABINET_8342f7b439312df98709d0093bab4dd1/images/vector_uxO.png"" alt style=""display: block;"" height=""20""></td>
																								</tr>
																								<tr>
																									<td align=""left"" class=""esd-block-text es-p10b es-m-txt-c"" esd-links-underline=""none"">
																										<p style=""line-height: 150%;"" class=""p_description"">{shortenedDescription}</p>
																									</td>
																								</tr>
																								<tr>
																									<td align=""left"" class=""esd-block-text es-p15b"" esd-links-underline=""none"">
																										<h2 style=""line-height: 150 %; font-family: licorice, helvetica, arial, cursive;""><strong>{shortenedCategory}</strong></h2>
																									</td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																		<!--[if mso]></td></tr></table></td></tr></table><![endif]-->
																	</td>
																</tr>
																<tr>
																	<td class=""esd-structure es-p20b es-p20r es-p20l"" align=""left"" esd-custom-block-id=""819790"" esdev-config=""h348"">
																		<table cellpadding = ""0"" cellspacing=""0"" width=""100%"">
																			<tbody>
																				<tr>
																					<td width = ""556"" class=""esd-container-frame"" align=""center"" valign=""top"">
																						<table cellpadding = ""0"" cellspacing=""0"" width=""100%"">
																							<tbody>
																								<tr>
																									<td align = ""center"" class=""esd-block-spacer es-p20t es-p15b es-p20r es-p20l"" style=""font-size:0"">
																										<table border = ""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"">
																											<tbody>
																												<tr>
																													<td style = ""border-bottom: 1px solid #cccccc; background:none; height:1px; width:100%; margin:0px 0px 0px 0px;""></td>
																												</tr>
																											</tbody>
																										</table>
																									</td>
																								</tr>
																								<tr>
																									<td align = ""center"" class=""esd-block-text"">
																										<h2><span style = ""color: #a9a9a9; font-size: 18px;""><s class=""p_old_price"">{product.Currency + currentPrice}</s></span>&nbsp;<span class=""p_price"">{product.Currency + currentPrice}</span></h2>
																									</td>
																								</tr>
																								<tr>
																									<td align = ""center"" class=""esd-block-spacer es-p15t es-p20b es-p20r es-p20l"" style=""font-size:0"">
																										<table border = ""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"">
																											<tbody>
																												<tr>
																													<td style = ""border-bottom: 1px solid #cccccc; background:none; height:1px; width:100%; margin:0px 0px 0px 0px;""></td>
																												</tr>
																											</tbody>
																										</table>
																									</td>
																								</tr>
																								<tr>
                                                                                    <td align=""center"" class=""esd-block-button"">
                                                                                        <!--[if mso]><a href=""{hostUrl}"" target=""_blank"" hidden>
	<v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" esdevVmlButton href=""{hostUrl}"" 
                style=""height:41px; v-text-anchor:middle; width:163px"" arcsize=""0%"" stroke=""f""  fillcolor=""#333333"">
		<w:anchorlock></w:anchorlock>
		<center style='color:#ffffff; font-family:arial, ""helvetica neue"", helvetica, sans-serif; font-size:15px; font-weight:700; line-height:15px;  mso-text-raise:1px'>OPEN NOW ►</center>
	</v:roundrect></a>
<![endif]-->
                                                                                        <!--[if !mso]><!-- --><span class=""msohide es-button-border"" style=""background: #333333;""><a href=""{hostUrl}"" class=""es-button"" target=""_blank"" style=""background: #333333; color: #ffffff; mso-border-alt: 10px solid #333333"">SHOP NOW ►</a></span>
                                                                                        <!--<![endif]-->
                                                                                    </td>
                                                                                </tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</td>
																</tr>
															</tbody>
														</table>
													</td>
												</tr>
											</tbody>
										</table>
										<table cellpadding=""0"" cellspacing=""0"" class=""es-footer esd-footer-popover"" align=""center"">
											<tbody>
												<tr>
													<td class=""esd-stripe"" align=""center"" esd-custom-block-id=""774406"">
														<table class=""es-footer-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" width=""600"" style=""background-color: transparent;"">
															<tbody>
																<tr>
																	<td class=""esd-structure es-p20t es-p20b es-p20r es-p20l"" align=""left"" esd-custom-block-id=""819795"">
																		<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																			<tbody>
																				<tr>
																					<td width=""560"" class=""esd-container-frame"" align=""left"">
																						<table cellpadding=""0"" cellspacing=""0"" width=""100%"">
																							<tbody>
																								<tr>
																									<td align=""center"" class=""esd-block-social es-p10t es-p10b es-p10l"" style=""font-size:0"">
																										<table cellpadding=""0"" cellspacing=""0"" class=""es-table-not-adapt es-social"">
																											<tbody>
																												<tr>
																													<td align=""center"" valign=""top"" class=""es-p35r"" esd-tmp-icon-type=""facebook""><a target=""_blank"" href=""https://viewstripo.email""><img title=""Facebook"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/square-black/facebook-square-black.png"" alt=""Fb"" width=""24"" height=""24""></a></td>
																													<td align=""center"" valign=""top"" class=""es-p35r"" esd-tmp-icon-type=""twitter""><a target=""_blank"" href=""https://viewstripo.email""><img title=""Twitter"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/square-black/twitter-square-black.png"" alt=""Tw"" width=""24"" height=""24""></a></td>
																													<td align=""center"" valign=""top"" class=""es-p35r"" esd-tmp-icon-type=""instagram""><a target=""_blank"" href=""https://viewstripo.email""><img title=""Instagram"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/square-black/instagram-square-black.png"" alt=""Inst"" width=""24"" height=""24""></a></td>
																													<td align=""center"" valign=""top"" esd-tmp-icon-type=""youtube""><a target=""_blank"" href=""https://viewstripo.email""><img title=""Youtube"" src=""https://tlr.stripocdn.email/content/assets/img/social-icons/square-black/youtube-square-black.png"" alt=""Yt"" width=""24"" height=""24""></a></td>
																												</tr>
																											</tbody>
																										</table>
																									</td>
																								</tr>
																								<tr>
																									<td align=""center"" class=""esd-block-text es-p10t es-p10b"" esd-links-color=""#333333"">
																										<p style=""font-size: 12px; color: #333333;"">You are receiving this email because you have visited our site or asked us about the regular newsletter. Make sure our messages get to your Inbox (and not your bulk or junk folders).<br><a target=""_blank"" style=""font-size: 12px; color: #333333;"" href=""https://viewstripo.email"">Privacy police</a> | <a target=""_blank"" style=""font-size: 12px; color: #333333;"" href=""https://viewstripo.email"">Unsubscribe</a></p>
																									</td>
																								</tr>
																							</tbody>
																						</table>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</td>
																</tr>
															</tbody>
														</table>
													</td>
												</tr>
											</tbody>
										</table>
									</td>
								</tr>
							</tbody>
						</table>
					</div>
				</body>
			</html>";
		}
	}
}
